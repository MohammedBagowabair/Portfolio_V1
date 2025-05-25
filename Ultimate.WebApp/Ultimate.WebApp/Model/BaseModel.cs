using Ultimate.WebApp.Enum;

namespace Ultimate.WebApp.Model
{
    public class BaseModel
    {
        private ModelStates _modelState = ModelStates.Loaded;
        public ModelStates ModelState
        {
            get => _modelState;
            set
            {
                if (_modelState != value)
                {
                    _modelState = value;

                }
            }
        }
    }
}
