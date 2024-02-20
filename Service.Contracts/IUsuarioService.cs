using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IUsuarioService
    {
        IEnumerable<UsuarioDto> GetAllUsers(bool trackChanges);
        UsuarioDto GetUser(Guid Id, bool trackChanges);
        UsuarioDto CreateUser(UsuarioForCreationDto user);
        IEnumerable<UsuarioDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        (IEnumerable<UsuarioDto> usuarios, string ids) CreateUserCollection
            (IEnumerable<UsuarioForCreationDto> userCollection);
        void DeleteUser(Guid userId, bool trackChanges);
        void UpdateUser(Guid userId, UsuarioForUpdateDto userForUpdate, bool trackChanges);
    }
}
