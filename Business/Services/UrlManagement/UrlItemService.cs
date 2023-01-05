using AutoMapper;
using Business.Contract.Models.UrlItemManagement;
using Business.Contract.Models.UserManagement;
using Business.Contract.Services.UrlItemManagement;
using Data.Contract.UnitOfWork;
using Domain.Entity.Base;
using Domain.Entity.UrlManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.UrlManagement
{
    public class UrlItemService : IUrlItemService
    {
        private IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UrlItemService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Create(CreateUrlItemDTO createLot, Guid ownerIdLink)
        {
            UrlItem newUrlItem = _mapper.Map<UrlItem>(createLot);
            newUrlItem.CreatorId = (await _unitOfWork.UserRepository.GetByIdLink(ownerIdLink)).Id;
            newUrlItem.CreatedDate = DateTime.Now;

            if(await _unitOfWork.UrlItemRepository.IsExist(newUrlItem.Url))
            {
                throw new Exception("This url is exist in DB");
            }

            await _unitOfWork.UrlItemRepository.Add(newUrlItem);
            Guid lotId = await _unitOfWork.UrlItemRepository.GetIdByUrl(newUrlItem.Url);
            return lotId;
        }

        public async Task Delete(Guid id)
        {
            var urlItem = await _unitOfWork.UrlItemRepository.GetById(id);

            if(urlItem != null)
            {
                await _unitOfWork.UrlItemRepository.Remove(urlItem);
                await _unitOfWork.Save();
            }
            else
            {
                throw new Exception("This url item is NOT exist in DB");
            }
            
        }

        public async Task<UrlItemDTO> GetById(Guid lotId)
        {
            UrlItem urlItem = await _unitOfWork.UrlItemRepository.GetById(lotId);
            UrlItemDTO urlItemDTO = _mapper.Map<UrlItemDTO>(urlItem);
            Person person =  await _unitOfWork.UserRepository.GetById(urlItem.CreatorId);
            urlItemDTO.Creator = _mapper.Map<PersonInfoDTO>(person);
            return urlItemDTO;
        }

        public async Task<IEnumerable<ShortUrlItemDTO>> GetAll()
        {
            IEnumerable<UrlItem> urlItems = await _unitOfWork.UrlItemRepository.GetAll();
            IEnumerable<ShortUrlItemDTO> urlItemDTOs = urlItems.Select(item => _mapper.Map<ShortUrlItemDTO>(item));
            return urlItemDTOs;
        }
    }
}
