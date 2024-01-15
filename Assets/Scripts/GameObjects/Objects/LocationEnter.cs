
public class LocationEnter : IInteractive
{
    public SceneChanger SceneChanger;
    public int SceneNumber;
    public override void Interact()
    {
        SceneChanger.FadeToLevel(SceneNumber);
    }
}
