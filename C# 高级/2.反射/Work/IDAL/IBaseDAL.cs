using Model;

namespace IDAL
{
    public interface IBaseDAL
    {
        T FindT<T>(int id) where T : BaseModel;
        List<T> FindAllT<T>() where T : BaseModel;
        bool InsertT<T>(T model) where T : BaseModel;
        bool UpdateT<T>(T model) where T : BaseModel;
        bool DeleteT<T>(int id) where T : BaseModel;

    }
}
