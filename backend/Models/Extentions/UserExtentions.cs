using Models.Entities;

namespace Models.Extentions
{
    public static class UserExtentions
    {
        public static void Update(this User previousModel, User newModel)
        {
            previousModel.Name = newModel.Name;
            previousModel.Email = newModel.Email;
        }
    }
}
