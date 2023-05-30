using AlAnon.Data;
using AlAnon.Models.Dtos;
using AlAnon.Repository.IRepository;
using AutoMapper;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AlAnon.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsuarioRepository(IMapper mapper, ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _db = db;
            _userManager = userManager;
        }
        public async Task<RespuestaDto<UsuarioDto>> DarPermiso(string id, string permiso)
        {
            var usuario = await _userManager.FindByIdAsync(id);
            if (usuario != null)
            {
                var roles = await _userManager.GetRolesAsync(usuario);
                if (!roles.Contains(permiso))
                {
                    var resultadoDeRole = await _userManager.AddToRoleAsync(usuario, permiso);
                    var UserClaims = await _userManager.GetClaimsAsync(usuario);
                    var resultadoDeClaim = await _userManager.ReplaceClaimAsync(usuario,
                                                                                UserClaims.FirstOrDefault(u => u.Type == JwtClaimTypes.Role),
                                                                                new Claim(JwtClaimTypes.Role, SD.Admin));
                    if (resultadoDeRole.Succeeded && resultadoDeClaim.Succeeded)
                    {
                        var usuarioDto = _mapper.Map<ApplicationUser, UsuarioDto>(usuario);
                        usuarioDto.Roles = (List<string>)await _userManager.GetRolesAsync(usuario);

                        return new RespuestaDto<UsuarioDto>()
                        {
                            Data = usuarioDto
                        };
                    }
                    else
                    {
                        return new RespuestaDto<UsuarioDto>()
                        {
                            Exito = false,
                            Data = new UsuarioDto(),
                            Error = "No se pudo agregar el role"
                        };
                    }
                }
                else
                {
                    var usuarioDto = _mapper.Map<ApplicationUser, UsuarioDto>(usuario);
                    usuarioDto.Roles = (List<string>)await _userManager.GetRolesAsync(usuario);

                    return new RespuestaDto<UsuarioDto>()
                    {
                        Data = usuarioDto
                    };
                }
            }

            return new RespuestaDto<UsuarioDto>()
            {
                Exito = false,
                Data = new UsuarioDto(),
                Error = "No existe el usuario"
            };

        }

        public async Task<RespuestaDto<UsuarioDto>> QuitarPermiso(string id, string permiso)
        {
            var usuario = await _userManager.FindByIdAsync(id);
            if (usuario != null)
            {
                var roles = await _userManager.GetRolesAsync(usuario);
                if (roles.Contains(permiso))
                {
                    var resultadoDeRole = await _userManager.RemoveFromRoleAsync(usuario, permiso);
                    var UserClaims = await _userManager.GetClaimsAsync(usuario);
                    var resultadoDeClaim = await _userManager.ReplaceClaimAsync(usuario,
                                                                                UserClaims.FirstOrDefault(u => u.Type == JwtClaimTypes.Role),
                                                                                new Claim(JwtClaimTypes.Role, SD.Usuario));
                    if (resultadoDeRole.Succeeded && resultadoDeClaim.Succeeded)
                    {
                        var usuarioDto = _mapper.Map<ApplicationUser, UsuarioDto>(usuario);
                        usuarioDto.Roles = (List<string>)await _userManager.GetRolesAsync(usuario);

                        return new RespuestaDto<UsuarioDto>()
                        {
                            Data = usuarioDto
                        };
                    }
                    else
                    {
                        return new RespuestaDto<UsuarioDto>()
                        {
                            Exito = false,
                            Data = new UsuarioDto(),
                            Error = "No se pudo quitar el role"
                        };
                    }
                }
                else
                {
                    var usuarioDto = _mapper.Map<ApplicationUser, UsuarioDto>(usuario);
                    usuarioDto.Roles = (List<string>)await _userManager.GetRolesAsync(usuario);

                    return new RespuestaDto<UsuarioDto>()
                    {
                        Data = usuarioDto
                    };
                }
            }

            return new RespuestaDto<UsuarioDto>()
            {
                Exito = false,
                Data = new UsuarioDto(),
                Error = "No existe el usuario"
            };

        }

        public async Task<RespuestaDto<List<UsuarioDto>>> ObtenerUsuarios()
        {
            var usuariosDtos = new List<UsuarioDto>();

            try
            {
                if (usuariosDtos != null)
                {
                    foreach (var usuario in _db.Miembros.ToList())
                    {
                        var nuevoUsuarioDto = _mapper.Map<ApplicationUser, UsuarioDto>(usuario);
                        nuevoUsuarioDto.Roles = (List<string>)await _userManager.GetRolesAsync(usuario);
                        usuariosDtos.Add(nuevoUsuarioDto);
                    }

                    return new RespuestaDto<List<UsuarioDto>>()
                    {
                        Data = usuariosDtos
                    };
                }
                else
                {
                    return new RespuestaDto<List<UsuarioDto>>()
                    {
                        Data = new List<UsuarioDto>()
                    };
                }
            }
            catch (Exception ex)
            {
                return new RespuestaDto<List<UsuarioDto>>()
                {
                    Error = ex.Message,
                    Exito = false,
                    Data = new List<UsuarioDto>()
                };
            }
        }
    }
}
