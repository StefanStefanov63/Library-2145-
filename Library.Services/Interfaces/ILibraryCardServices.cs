using Library.Services.ViewModelsClasses;

namespace Library.Services.Interfaces
{
    public interface ILibraryCardServices
    {
        void RegisterNewLibraryCard(string aName);
        void DeleteLibraryCardByName(string aName);
        void UpdateLibraryCardName(string aOldName, string aNewName);
        ICollection<LibraryCardViewModel> GetAllLibraryCards();
    }
}
