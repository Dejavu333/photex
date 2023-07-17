namespace PHOTEX.MODEL.REPOSITORY
{
    public interface IPhotoRepository<P>
    {
        Task<P> readOne();
    }
}
