namespace InnoSetup.ScriptBuilder;

public interface IComponentsAndTasksBuilder<TBuilder>
{
    TBuilder Components(string value);
    TBuilder Tasks(string value);
}