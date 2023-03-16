namespace Kaynir.Localization.Localizables
{
    public class LocalizedListener : LocalizedBehaviour
    {
        private ILocalizable[] _localizables;

        protected override void Start()
        {
            _localizables = GetComponentsInChildren<ILocalizable>();
            base.Start();
        }

        protected override void Localize(string language)
        {
            for (int i = 0; i < _localizables.Length; i++)
            {
                _localizables[i].Localize(language);
            }
        }
    }
}