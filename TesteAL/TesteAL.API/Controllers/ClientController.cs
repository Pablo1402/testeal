using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TesteAL.Domain.CustomExceptions;
using TesteAL.Domain.Entities;
using TesteAL.Domain.Interfaces.Services;
using TesteAL.Service.ViewModel;

namespace TesteAL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _svc;
        protected readonly IMapper _mapper;
        public ClientController(IClientService svc, IMapper mapper)
        {
            _svc = svc;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<ClientViewModel>>>> GetAll()
        {
            try
            {
                var clientList = await _svc.GetAll();
                var data = _mapper.Map<List<ClientViewModel>>(clientList);
                return new BaseResponse<List<ClientViewModel>>()
                {
                    Data = data,
                    Message = null
                };
            }
            catch (AppExceptions appex)
            {
                return StatusCode(appex.status, new BaseResponse<ClientViewModel>()
                {
                    Data = null ,
                    Message = appex.Message
                });

            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), new BaseResponse<ClientViewModel>()
                {
                    Data = null,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<ClientViewModel>>> GetById(Guid id)
        {
            try
            {
                var client = await _svc.GetById(id);
                var data = _mapper.Map<ClientViewModel>(client);
                return new BaseResponse<ClientViewModel>()
                {
                    Data = data,
                    Message = null
                };
            }
            catch (AppExceptions appex)
            {
                return StatusCode(appex.status, new BaseResponse<ClientViewModel>()
                {
                    Data = null,
                    Message = appex.Message
                });

            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), new BaseResponse<ClientViewModel>()
                {
                    Data = null,
                    Message = ex.Message
                });
            }
        }


        [HttpPost]
        public async Task<ActionResult<BaseResponse<ClientViewModel>>> Save(ClientViewModel model)
        {
            try
            {
                var client = await _svc.Save(_mapper.Map<Client>(model));
                var data = _mapper.Map<ClientViewModel>(client);
                return new BaseResponse<ClientViewModel>()
                {
                    Data = data,
                    Message = "Cliente salvo com sucesso! "
                };
            }
            catch (AppExceptions appex)
            {
                return StatusCode(appex.status, new BaseResponse<ClientViewModel>()
                {
                    Data = null,
                    Message = appex.Message
                });

            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), new BaseResponse<ClientViewModel>()
                {
                    Data = null,
                    Message = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<ClientViewModel>>> Update(ClientViewModel model, Guid id)
        {
            try
            {
                var client = await _svc.Update(_mapper.Map<Client>(model),id);
                var data = _mapper.Map<ClientViewModel>(client);
                return new BaseResponse<ClientViewModel>()
                {
                    Data = data,
                    Message = "Cliente atualizado com sucesso! "
                };
            }
            catch (AppExceptions appex)
            {
                return StatusCode(appex.status, new BaseResponse<ClientViewModel>()
                {
                    Data = null,
                    Message = appex.Message
                });

            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), new BaseResponse<ClientViewModel>()
                {
                    Data = null,
                    Message = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<ClientViewModel>>> Delete(Guid id)
        {
            try
            {
                await _svc.Delete(id);
                return new BaseResponse<ClientViewModel>()
                {
                    Data = null,
                    Message = "Cliente removido com sucesso! "
                };
            }
            catch (AppExceptions appex)
            {
                return StatusCode(appex.status, new BaseResponse<ClientViewModel>()
                {
                    Data = null,
                    Message = appex.Message
                });

            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), new BaseResponse<ClientViewModel>()
                {
                    Data = null,
                    Message = ex.Message
                });
            }
        }
    }
}
