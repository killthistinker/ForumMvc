using exam8.Services.Abstractions;

namespace exam8.ViewModels
{
    public class DefaultUserImageAvatar : IDefaultUserImageAvatar
    {
        private readonly string _path;

        public DefaultUserImageAvatar(string path)
        {
            _path = path;
        }

        public string GetPathToDefaultImage() => _path;
    }
}