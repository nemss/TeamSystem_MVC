namespace TeamSystem.Services.Matches.Interfaces
{
    using System;
    using System.Threading.Tasks;
    using TeamSystem.Services.Matches.Models;

    public interface IPlayerService
    {
        Task CreateAsync(string firstName, 
                         string secondName, 
                         string LastName, 
                         string ucn, 
                         DateTime birthDate, 
                         int teamId, 
                         int modelId, 
                         bool isReserved);

        Task EditAsync(string firstName,
                       string secondName,
                       string LastName,
                       string ucn, 
                       DateTime birthDate,
                       int teamId, 
                       int modelId,
                       bool isReserved);

        Task DeleteAsync(int id);

        Task GetByIdAsync(int id);
    }
}
