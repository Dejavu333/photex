namespace PHOTEX.SERVICE
{
    public interface IPhotoService<T,P>
    {
        Task<P> shotPhoto();
        Task<P> localPhoto();
        T textFromPhoto(P photo);
    }
}
