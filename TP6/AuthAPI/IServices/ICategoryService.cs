using AuthAPI.DTOS;

namespace AuthAPI.IServices
{
    public interface ICategorieService
    {
        IEnumerable<CategorieDTO> Index();
        CategorieDTO Create(CategorieDTO categorie);
        CategorieDTO Edit(CategorieDTO c, int id);
        void Delete(int id);
    }

}
