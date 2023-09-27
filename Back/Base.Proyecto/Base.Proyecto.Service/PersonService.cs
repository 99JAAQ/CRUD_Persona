
using AutoMapper;
using Base.Proyecto.Common;
using Base.Proyecto.Common.Dto;
using Base.Proyecto.Common.Dto.Person;
using Base.Proyecto.Infraestructure.Interfaces;
using Base.Proyecto.Infraestructure.Models;
using Base.Proyecto.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Base.Proyecto.Service
{
    public class PersonService: IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mapper = mapper;

        }

        public BodyResponse<object> GetAll()
        {
            IEnumerable<Person> person = _unitOfWork.Person.Where(a=> a.Estado);
            return new BodyResponse<object>
            {
                Code = person != null ? (int)HttpStatusCode.Created : (int)HttpStatusCode.BadRequest,
                IsSuccess = person != null,
                Message = person != null ? "Datos obtenidos" : "No hay información",
                Data = person
            };
        }

        public BodyResponse<object> GetById(Guid id)
        {
            Person person = _unitOfWork.Person.FirstOrDefault(x => x.Id == id);
            return new BodyResponse<object>
            {
                Code = person != null ? (int)HttpStatusCode.Created : (int)HttpStatusCode.BadRequest,
                IsSuccess = person != null,
                Message = person != null ? "Datos obtenidos" : "No hay información",
                Data = person
            };
        }

        public BodyResponse<object> Add(AddPersonDto model)
        {
            Person exist = _unitOfWork.Person.Find(a => a.Cedula == model.Cedula).FirstOrDefault();
            if (exist != null) throw new BusinessException("Ya existe un usuario con esta cedula");

            Person newPerson = _mapper.Map<Person>(model);
            newPerson.Estado = true;

            _unitOfWork.Person.Add(newPerson);
            bool saved = _unitOfWork.Save() > 0;

            return new BodyResponse<object>
            {
                Code = saved ? (int)HttpStatusCode.Created : (int)HttpStatusCode.BadRequest,
                IsSuccess = saved,
                Message = saved ? "Exitoso" : "Falló",
                Data = "OK"
            };
        }

        public BodyResponse<object> Update(AddPersonDto model)
        {
            Person person = _unitOfWork.Person.Find(a => a.Id == model.Id).FirstOrDefault();
            if (person == null) throw new BusinessException("La persona no existe");

            _mapper.Map(model, person);

            _unitOfWork.Person.Update(person);
            bool saved = _unitOfWork.Save() > 0;

            return new BodyResponse<object>
            {
                Code = saved ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest,
                IsSuccess = saved,
                Message = saved ? "Exitoso" : "Falló",
                Data = "OK"
            };
        }

        public BodyResponse<object> Delete(Guid id)
        {
            Person person = _unitOfWork.Person.Find(a => a.Id == id).FirstOrDefault();
            if (person == null) throw new BusinessException("La persona no existe");
            person.Estado = false;

            _unitOfWork.Person.Update(person);
            bool saved = _unitOfWork.Save() > 0;

            return new BodyResponse<object>
            {
                Code = saved ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest,
                IsSuccess = saved,
                Message = saved ? "Exitoso" : "Falló",
                Data = "OK"
            };
        }


    }
}
