using Business.Contract.Models.UrlItemManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract.Services.UrlItemManagement
{
    public interface IUrlItemService
    {
        Task<Guid> Create(CreateUrlItemDTO createLot, Guid ownerId);
        Task Delete(Guid id);
        Task<UrlItemDTO> GetById(Guid lotId);
        Task<IEnumerable<ShortUrlItemDTO>> GetAll();
    }
}
