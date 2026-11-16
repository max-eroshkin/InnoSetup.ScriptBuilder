# TASKS — миграция InnoSetup.ScriptBuilder на Inno Setup 7.1.1

Референс: `jrsoftware/issrc`, тег **is-7_1_1** (`ISHelp/isetup.xml`, `whatsnew.htm`).
Текущее состояние библиотеки соответствует **6.3.0**.

Правила работы:

- один коммит = один раздел этого файла (`Коммит N`);
- после каждого коммита: `dotnet build tests/BuilderTests/BuilderTests.csproj` + `dotnet test tests/BuilderTests/BuilderTests.csproj`;
- тесты локально полностью зелёные (86/86) — любое падение считать регрессией;
- новые файлы — **UTF-8 with BOM**, usings внутри namespace (StyleCop `SA1200`/`SA1412` — Error);
- все новые публичные члены — с XML-doc и ссылкой на `https://jrsoftware.org/ishelp/index.php?topic=...`;
- всё устаревшее — `[Obsolete("Removed in Inno Setup <ver>: <замена>")]` / `[Obsolete("Obsolete since Inno Setup <ver>: <замена>")]`;
- **не** коммитить `*.sln` правки и собранные артефакты.

Сверка «документация 6.3.3 → 7.1.1» дала: +1 секция (`[ISSigKeys]`), +19 директив `[Setup]`, +6 параметров и +4 флага `[Files]`, +1 параметр `[Run]`, 0 изменений в `[Dirs]`/`[Icons]`/`[Registry]`/`[INI]`/`[Languages]`/`[Types]`/`[Messages]`, 0 изменений в Common Parameters и Components/Tasks Parameters, 0 новых констант.

---

## [ ] Коммит 1 — Инфраструктура форматирования значений

Цель: научиться печатать значения, которые нельзя вывести из имени члена enum, и типы с неявными преобразованиями. Публичный API секций на этом шаге **не** расширяется.

- [x] **1.1** Новый файл `src/InnoSetup.ScriptBuilder/Constants/IssValueAttribute.cs`
  - `[AttributeUsage(AttributeTargets.Field)] public sealed class IssValueAttribute : Attribute`
  - `public IssValueAttribute(string value)`, `public string Value { get; }`
  - Назначение: значения вида `enhanced/nopassword`, `pbkdf2/220000`.

- [x] **1.2** Переписать `src/InnoSetup.ScriptBuilder/Utils/ValueExtensions.cs` → `GetString(this Enum e)`
  - разбить `e.ToString("g")` по `", "`;
  - для каждого токена: если у члена есть `IssValueAttribute` — взять `Value` как есть; иначе прежняя трансформация (`Replace("_", "")` + `ToLower()`);
  - закэшировать `(Type, memberName) -> string` (обычный `static Dictionary` под `lock` — `netstandard2.0`);
  - **не менять** поведение для `int`/`uint`/`long`/`ulong`/`string`/`List<GroupPermission>`.

- [x] **1.3** Новый файл `src/InnoSetup.ScriptBuilder/Constants/IssColor.cs`
  - `public readonly struct IssColor : IEquatable<IssColor>`, свойство `public string Value { get; }`, `ToString() => Value`;
  - `implicit operator IssColor(long)` и `(int)` → `"$" + значение как 6 hex-цифр` (`$bbggrr`, Delphi `TColor`);
  - `implicit operator IssColor(string)` → как есть (`"#fff"`, `"#rrggbb"`, `"cornflowerblue"`, `"none"`, `"window"`);
  - `static IssColor Hex(int r, int g, int b)` → `"#rrggbb"`;
  - `static IssColor Named(string)` → имя без валидации;
  - статические `None`, `Window` + 16 базовых имён (black, maroon, green, olive, navy, purple, teal, gray, silver, red, lime, yellow, blue, fuchsia, aqua, white).

- [x] **1.4** Новый файл `src/InnoSetup.ScriptBuilder/Constants/IssYesNo.cs`
  - `public readonly struct IssYesNo`, `public string Value { get; }`, `ToString() => Value`;
  - `implicit operator IssYesNo(YesNo)` → `yes`/`no`/`auto` (через существующий `GetString`);
  - `implicit operator IssYesNo(string)` → как есть, **без кавычек** (scripted boolean expression, например `{code:IsSomething}`);
  - нужен для 9 директив `[Setup]` с формулировкой `yes or no, or a scripted boolean expression`.

- [x] **1.5** `ValueExtensions.GetString(this object value, bool needQuotes = true)` — добавить ветки
  - `IssColor color => color.Value`
  - `IssYesNo flag => flag.Value`

- [x] **1.6** `[Obsolete]`-чистка существующего API (без удаления членов — кроме 1.7)
  - `Model/SetupSection/SetupSection.cs`: `BackColor`, `BackColor2`, `BackColorDirection`, `BackSolid`, `WindowResizable`, `WindowShowCaption`, `WindowStartMaximized`, `WindowVisible`, `WizardResizable` → `Obsolete("Removed in Inno Setup 6.4: use WizardImageBackColor / WizardStyle instead")`;
  - там же: `Options` + весь `Model/SetupSection/SetupOption.cs` → `Obsolete("Obsolete since Inno Setup 6.0: use the individual [Setup] directives instead")`;
  - там же: `WizardSizePercentX`, `WizardSizePercentY` → `Obsolete("Obsolete since Inno Setup 3.0.5: use WizardSizePercent (\"120,120\") instead")`;
  - там же: `ShowUndisplayableLanguages` → `Obsolete("Has no effect since Inno Setup 6.0 (Unicode-only builds)")`;
  - `Model/LangOptionsSection/LangOptionsSection.cs`: `TitleFontName`, `TitleFontSize`, `CopyrightFontName`, `CopyrightFontSize` → `Obsolete("Removed in Inno Setup 6.4")`;
  - `Constants/InnoConstants.cs`: `Inno.Hwnd` → `Obsolete("Removed in Inno Setup 6.4")`;
  - `Model/SetupSection/BackColorDirection.cs` — enum оставить, но пометить `Obsolete` вместе со свойством.

- [x] **1.7** Баг-фикс: `Model/SetupSection/WizardImageAlphaFormat.cs`
  - `Ignored` → **`None`** (документация и в 6.3.3, и в 7.1.1: `none | defined | premultiplied`; `ignored` — невалидное значение ISS, свойство никогда не работало корректно);
  - член не оставлять как алиас (дубликат значения делает `Enum.ToString()` недетерминированным) — это осознанное breaking rename, отразить в release notes.

- [x] **1.8** Баг-фикс: `Model/IconsSection/IconFlags.cs`
  - `FolderShortcut` (флаг `foldershortcut` удалён в Inno Setup 6.3.0) → `[Obsolete("Removed in Inno Setup 6.3")]`, бит `1 << 7` пометить как «не переиспользовать».

- [x] **1.9** Тесты
  - новый `tests/BuilderTests/ValueFormattingTests.cs`:
    - `FileFlags.Sign | FileFlags._32bit` → `"sign 32bit"` (регресс на `_`-хендлинг);
    - `Permissions`, `Sids`, `RegistryKeys`, `DeleteTypes` — по одному представителю (регресс lower-case);
    - `IssColor`: `(long)255` → `"$0000ff"`, `"#fff"`, `"cornflowerblue"`, `IssColor.None`;
    - `IssYesNo`: `(YesNo)YesNo.Yes` → `"yes"`, `"{code:IsX}"` → как есть;
    - `IssValueAttribute` — на private тестовом enum + в `[Flags]`-комбинации.
  - в `tests/BuilderTests/BuilderTests.csproj` добавить `<NoWarn>$(NoWarn);CS0618</NoWarn>` (иначе `TestBuilder` не соберётся после 1.6).

- [x] **1.10** `src/InnoSetup.ScriptBuilder/InnoSetup.ScriptBuilder.csproj`: `PackageReleaseNotes` → `Upgraded to Inno Setup 7.1.1` (версию **не** менять до Коммита 6).

---

## [x] Коммит 2 — Constants

- [x] **2.1** `Constants/InnoConstants.cs`: новый вложенный статический класс **`Auto`** (14 констант)
  - `{autoappdata}`, `{autocf}`, `{autocf32}`, `{autocf64}`, `{autodesktop}`, `{autodocs}`, `{autofonts}`, `{autopf}`, `{autopf32}`, `{autopf64}`, `{autoprograms}`, `{autostartmenu}`, `{autostartup}`, `{autotemplates}`
  - XML-doc: «автоматически маппится на common-форму, кроме non administrative install mode, где маппится на user-форму; документация рекомендует использовать именно auto-константы».

- [x] **2.2** Там же, в legacy-класс с `[Obsolete("Use InnoConstants.Directories...")]`: добавить 8 алиасов
  - `{pf}`, `{pf32}`, `{pf64}`, `{cf}`, `{cf32}`, `{cf64}`, `{fonts}`, `{sendto}` — с указанием замены (`Auto.*` / `Directories.*` / `Shell.*`).

- [x] **2.3** `BuilderTests/ConstantTests.cs`: тесты значений `Auto.*` (все 14) и legacy-алиасов (8).

- [x] **2.4** `README.md` / `examples/Examples/`: заменить литералы `"{autofonts}"`/`"{autopf}"` на `InnoConstants.Auto.*`.

---

## [x] Коммит 3 — `[Files]`, `[Run]`/`[UninstallRun]`, новая секция `[ISSigKeys]`

- [x] **3.1** `Model/FileSection/FileEntry.cs` — 6 новых параметров (`string`)
  - `ISSigAllowedKeys`, `Hash`, `ExtractArchivePassword`, `DownloadISSigSource`, `DownloadUserName`, `DownloadPassword`
  - порядок объявления — **после** `StrongAssemblyName`, **до** `Permissions`/`Flags`/`Components` (порядок = порядок вывода).

- [x] **3.2** `Constants/FileFlags.cs` — 4 новых бита (enum `ulong`, занято до `1ul << 40`)
  - `Download = 1ul << 41`, `ExtractArchive = 1ul << 42`, `ISSigVerify = 1ul << 43`, `NoTimestamp = 1ul << 44`
  - XML-doc: взаимоисключения (`download` требует `external` + `ignoreversion` + `DestName` + `ExternalSize`; `download` нельзя с `comparetimestamp`/`recursesubdirs`/`skipifsourcedoesntexist`; `issigverify` нельзя с `sign`/`signonce`; `notimestamp` нельзя с `comparetimestamp`/`touch`) — **только документация**, runtime-валидацию не вводить.

- [x] **3.3** `Builder/FilesBuilder.cs` — 6 one-liner'ов с именами **точно как у свойств** (`SetPropertyValue` резолвит по `[CallerMemberName]`).

- [x] **3.4** `Model/RunSection/RunEntry.cs` + `Builder/RunBuilder.cs` — параметр `OnLog` (`string`)
  - XML-doc: только `[Run]`, требует флаг `LogOutput`; `RunEntry` общий с `[UninstallRun]`, поэтому валидации нет.

- [x] **3.5** Новая секция `[ISSigKeys]`
  - `Model/IssigKeysSection/IssigKeyEntry.cs` : **`ModelBase`** (не `CommonParameterSectionEntryBase` — у секции нет `Languages`/`MinVersion`/`Check`), свойства: `Name`, `Group`, `KeyID`, `KeyFile`, `PublicX`, `PublicY`, `RuntimeID` (все `string`);
  - `Builder/IssigKeysBuilder.cs` : `ParameterSectionBuilderBase<IssigKeysBuilder, IssigKeyEntry>`, `SectionName => "ISSigKeys"`, методы `CreateEntry(string name, string keyFile)`, `CreateEntryFromPublicKey(string name, string publicX, string publicY)`, `Group/KeyID/KeyFile/PublicX/PublicY/RuntimeID`;
  - `Builder/Abstractions/IIssigKeyEntryBuilder.cs`;
  - `Builder/IssBuilder.cs`: поле `_issigKeys`, свойство **`ISSigKeys`** (такое написание обязательно — `BuilderTests.NamingConsistency` требует `SectionName == property.Name`), вызов `_issigKeys.Write(writer)` **после `_langOptionsBuilder`, до `_messages`**.

- [x] **3.6** Тесты
  - `TestBuilder.cs`: заполнить 6 параметров `[Files]`, `OnLog`, создать запись в `[ISSigKeys]` (иначе упадёт `BuilderTests.TestBuilderContainsAllAvailableSections`);
  - `FilesTests.cs`: +6 параметров и `Flags: external ignoreversion download extractarchive issigverify` в `ReferenceData` (порядок битов, а не порядок объявления);
  - `RunSectionTests.cs`: +`OnLog`;
  - новый `IssigKeysTests.cs` : `ParameterSectionTestsBase<IssigKeyEntry>`, `SectionName => "ISSigKeys"`.

---

## [x] Коммит 4 — `[Setup]`: новые директивы 6.4–6.7 + перетипизация

- [x] **4.1** Новые enum-файлы
  - `Model/SetupSection/ArchiveExtraction.cs`: `Auto, Basic, EnhancedNoPassword` (`[IssValue("enhanced/nopassword")]`), `Enhanced`, `Full`; (сверено с `isetup.xml` is-7_1_1: значения — `auto`, `basic`, `enhanced/nopassword`, `enhanced`, `full`, комбинации `enhanced/full` не существует)
  - `Model/SetupSection/PrecompiledFileVerifications.cs`: `[Flags]` — `Setup = 1 << 0`, `SetupCustomStyle = 1 << 1`, `SetupLdr = 1 << 2`, `Is7z = 1 << 3`, `IsBunzip = 1 << 4`, `IsUnzlib = 1 << 5`, `IsLzma = 1 << 6`;
  - `Model/SetupSection/EncryptionMode.cs`: `No, Yes, Full` (6.5.0, `full` = шифрование всей установки, пароль только `/PASSWORD=`).

- [x] **4.2** `Model/SetupSection/SetupSection.cs` — новые свойства

  | Свойство | Тип | Версия |
  |---|---|---|
  | `ArchiveExtraction` | `ArchiveExtraction?` | 6.5 |
  | `CloseApplicationsFilterExcludes` | `string` | 6.4.2 |
  | `DisablePrecompiledFileVerifications` | `PrecompiledFileVerifications?` | 6.5 |
  | `EncryptionKeyDerivation` | `string` (`pbkdf2` / `pbkdf2/<n>`, default `pbkdf2/220000`) | 6.4 |
  | `RedirectionGuard` | `YesNo?` (default `yes`) | 6.7 |
  | `WizardBackColor`, `WizardBackColorDynamicDark` | `IssColor?` | 6.7 |
  | `WizardBackImageFile`, `WizardBackImageFileDynamicDark` | `string` | 6.7 |
  | `WizardBackImageOpacity` | `int?` (0–255, default 255) | 6.7 |
  | `WizardImageFileDynamicDark`, `WizardSmallImageFileDynamicDark` | `string` | 6.6 |
  | `WizardImageBackColor`, `WizardSmallImageBackColor` (долг 6.x) | `IssColor?` | 6.0 |
  | `WizardImageBackColorDynamicDark`, `WizardSmallImageBackColorDynamicDark` | `IssColor?` | 6.6 |
  | `WizardImageOpacity` | `int?` (0–255, default 255) | 6.6.1 |
  | `WizardKeepAspectRatio` | `YesNo?` (default `yes`) | 6.6 |
  | `WizardStyleFile`, `WizardStyleFileDynamicDark` | `string` | 6.6 |
  | `AlwaysCreateUninstallIcon`, `DisableAppendDir`, `DontMergeDuplicateFiles`, `MessagesFile`, `UninstallIconFile`, `UninstallIconName`, `UninstallStyle` | `string`, все `[Obsolete]` | долг полноты obsolete-списка |

- [x] **4.3** Перетипизация существующих свойств
  - `Encryption`: `YesNo?` → `EncryptionMode?` (breaking);
  - `WizardStyle` (`Model/SetupSection/WizardStyle.cs`) → `[Flags]`: `Classic = 1, Modern = 1 << 1, Light = 1 << 2, Dark = 1 << 3, Dynamic = 1 << 4, Polar = 1 << 5, Slate = 1 << 6, Stellar = 1 << 7, Windows11 = 1 << 8, Zircon = 1 << 9, ExcludeLightButtons = 1 << 10, ExcludeLightControls = 1 << 11, HideBevels = 1 << 12, IncludeTitleBar = 1 << 13`;
  - `WizardImageAlphaFormat.Ignored` → `None` (см. 1.7).

- [x] **4.4** `Builder/SetupBuilder.cs` — one-liner'ы на каждое новое свойство (имена = имена свойств) + хелперы
  - `EncryptionKeyDerivation()` → `"pbkdf2"`;
  - `EncryptionKeyDerivation(int iterations)` → `"pbkdf2/<iterations>"` (валидация `1..2147483647`);
  - перегрузки для `IssColor`-свойств (`IssColor`, `long`, `string` — неявные преобразования покрывают, отдельные перегрузки не нужны, достаточно одного метода с `IssColor`).

- [x] **4.5** Тесты
  - `TestBuilder.cs`: выставить все новые свойства (включая obsolete — они тоже проверяются рефлексией);
  - `SetupTests.ReferenceData`: +21 строка; значения: `Encryption` → `yes`, `WizardStyle` → `modern dark dynamic` (комбинация, проверяющая `[Flags]`), `WizardImageAlphaFormat` → `none`, цвета → `$000011`/`#fff`.

---

## [ ] Коммит 5 — `[Setup]`: 7.0 + scripted booleans

- [ ] **5.1** `Model/SetupSection/SetupArchitecture.cs` : `X86, X64` (default `x86`); свойство `SetupArchitecture?` в `SetupSection`.

- [ ] **5.2** `Model/SetupSection/SetupLdrMode.cs` : `No, Yes, X86, X64`; `SetupSection.UseSetupLdr`: `YesNo?` → `SetupLdrMode?` (breaking, 6.7.0).

- [ ] **5.3** `SetupSection.DiskSliceSize`: `uint?` → `ulong?` (7.0 поднял предел до `9223372036800000000` для 64-bit Setup).

- [ ] **5.4** Scripted boolean expressions — перевод 9 свойств на `IssYesNo?`
  - `Uninstallable`, `ChangesAssociations`, `ChangesEnvironment`, `UsePreviousAppDir`, `UsePreviousGroup`, `UsePreviousSetupType`, `UsePreviousTasks`, `UsePreviousUserInfo`;
  - `CreateUninstallRegKey`: `string` → `IssYesNo?`.

- [ ] **5.5** Проверить компиляцию неявных преобразований на nullable: `Uninstallable(YesNo.Yes)` и `Uninstallable("{code:IsX}")`
  - если C# не выводит `YesNo → IssYesNo?` — добавить в `SetupBuilder` перегрузки `Uninstallable(YesNo)` / `Uninstallable(string)` и т.п. для всех 9 свойств.

- [ ] **5.6** Тесты
  - `EnumTests` автоматически проверит уникальность битов новых `[Flags]` (`PrecompiledFileVerifications`, `WizardStyle`);
  - `TestBuilder.cs` + `SetupTests.ReferenceData`: `SetupArchitecture` → `x64`, `UseSetupLdr` → `x64`, `DiskSliceSize` → большое значение, одно из yes/no-свойств → `{code:IsSomething}` (проверка отсутствия кавычек).

---

## [ ] Коммит 6 — Документация, версия, AGENTS.md, приёмка

- [ ] **6.1** `src/InnoSetup.ScriptBuilder/InnoSetup.ScriptBuilder.csproj`: `<Version>7.1.1</Version>`, `PackageReleaseNotes` — перечислить breaking changes (`Encryption`, `UseSetupLdr`, `WizardStyle`, `WizardImageAlphaFormat`, `IssYesNo`).

- [ ] **6.2** `README.md` — раздел «Upgrading from 6.3»: таблица замен; примеры новых возможностей
  - `external download ignoreversion` + `Hash` / `DownloadUserName` / `DownloadPassword`;
  - `extractarchive` + `ExtractArchivePassword`;
  - `issigverify` + `[ISSigKeys]` + `ISSigAllowedKeys`;
  - `WizardStyle=modern dynamic dark`, `WizardBackColor`/`WizardBackImageFile`;
  - `Encryption=full`, `SetupArchitecture=x64`;
  - `InnoConstants.Auto.*`.

- [ ] **6.3** `examples/Examples/` — обновить существующие примеры под новые константы/типы.

- [ ] **6.4** `AGENTS.md` — привести в соответствие с реальностью
  - `src/InnoSetup.ScriptBuilder/InnoSetup.ScriptBuilder.csproj` — **уже** с маленькой `p`, `LangVersion=13`, трап про 7.3 неактуален;
  - `BuilderTests` — **net10.0**, `global.json` → SDK `10.0.100`, `DOTNET_ROLL_FORWARD` не нужен;
  - добавить порядок `[ISSigKeys]` в `IssBuilder.Write()`;
  - правило: любой `[Obsolete]` — обязательно с версией Inno Setup и заменителем.

- [ ] **6.5** Приёмка
  - `dotnet build tests/BuilderTests/BuilderTests.csproj` — без warning'ов (кроме `CS0618` в тестах);
  - `dotnet test tests/BuilderTests/BuilderTests.csproj` — зелёный, кроме известного `CodeTests` (CRLF);
  - `dotnet pack src/InnoSetup.ScriptBuilder/InnoSetup.ScriptBuilder.csproj -o /tmp/opencode/pack` — версия `7.1.1`, README внутри пакета;
  - ручная сверка: `grep -rn "Obsolete(" src/InnoSetup.ScriptBuilder` — у каждого сообщения есть версия;
  - ручная сверка с `isetup.xml` (is-7_1_1): все 174 директивы `[Setup]` либо в модели, либо в obsolete-списке 4.2/1.6.

---

## Вне рамок (не делать)

- `Compression=zstd` и `ZstdNumThreads` — это **7.2-dev**, в 7.1.1 отсутствуют.
- Удаление `powerusers` / `IsPowerUserLoggedOn` — 7.2-dev.
- Pascal Scripting API (support functions, support classes, `OnLog`-колбэки, `Check`/`BeforeInstall`/`AfterInstall` типизация) — библиотека генерирует текст скрипта, не Pascal-код.
- Булевы выражения в `ArchitecturesAllowed` / `ArchitecturesInstallIn64BitMode` (документация 7.1 их допускает, типизированный `[Flags] Architectures` их не выражает) — использовать `Parameter(name, value)`; зафиксировать в XML-doc.
