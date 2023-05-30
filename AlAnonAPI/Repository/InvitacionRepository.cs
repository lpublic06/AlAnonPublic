using AlAnonAPI.Models.Dtos;
using AlAnonAPI.Models;
using AlAnonAPI.Repository.IRepository;
using AutoMapper;
using AlAnonAPI.Data;
using System.Globalization;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Http;

namespace AlAnonAPI.Repository
{
	public class InvitacionRepository : IInvitacionRepository
	{
		private readonly ApplicationDbContext _db;
		private readonly IMapper _mapper;

		public InvitacionRepository(ApplicationDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}

		public async Task<RespuestaDto<List<InvitacionDto>>> BorrarInvitacion(int idDeInvitacion)
		{
			// Look for invitation by id
			var invitacionDeDb = _db.Invitaciones.FirstOrDefault(r => r.Id == idDeInvitacion);
			if (invitacionDeDb != null)
			{
				_db.Invitaciones.Remove(invitacionDeDb);
				await _db.SaveChangesAsync();

				// Return a full list
				return new RespuestaDto<List<InvitacionDto>>()
				{
					Data = _mapper.Map<IEnumerable<Invitacion>, IEnumerable<InvitacionDto>>(_db.Invitaciones).ToList()
				};
			}

			// If group doesn't exist
			return new RespuestaDto<List<InvitacionDto>>()
			{
				Error = "Invitacion no existe",
				Exito = false
			};
		}

		public async Task<RespuestaDto<InvitacionDto>> CrearEditarInvitacion(InvitacionDto nuevaInvitacionDto)
		{
			//Check if Invitation exists?
			var nuevaInvitacion = _mapper.Map<InvitacionDto, Invitacion>(nuevaInvitacionDto);

			if (nuevaInvitacion != null)
			{
				var invitacionDeDb = _db.Invitaciones.FirstOrDefault(r => r.Id == nuevaInvitacion.Id);
				if (invitacionDeDb != null)
				{
					// Edit Invitation
					invitacionDeDb.ImagePath = nuevaInvitacion.ImagePath;
					invitacionDeDb.Alt = nuevaInvitacion.Alt;
					invitacionDeDb.Fecha = nuevaInvitacion.Fecha;
					invitacionDeDb.FechaEntera = nuevaInvitacion.FechaEntera;
					invitacionDeDb.Nombre = nuevaInvitacion.Nombre;

					_db.Invitaciones.Update(invitacionDeDb);
					await _db.SaveChangesAsync();

					return new RespuestaDto<InvitacionDto>()
					{
						Data = _mapper.Map<Invitacion, InvitacionDto>(invitacionDeDb)
					};
				}

				// Insert invitation
				_db.Invitaciones.Add(nuevaInvitacion);
				await _db.SaveChangesAsync();

				return new RespuestaDto<InvitacionDto>()
				{
					Data = _mapper.Map<Invitacion, InvitacionDto>(nuevaInvitacion)
				};
			}

			// Invitation is null
			return new RespuestaDto<InvitacionDto>()
			{
				Error = "Error Creando Invitacion",
				Exito = false,
				Data = nuevaInvitacionDto
			};
		}

		public async Task<RespuestaDto<InvitacionDto>> ObtenerInvitacion(int idDeInvitacion)
		{
			// Invitations are greater than 0 id
			if (idDeInvitacion > 0)
			{
				var invitacionDeDb = _db.Invitaciones.FirstOrDefault(r => r.Id == idDeInvitacion);
				if (invitacionDeDb != null)
				{
					return new RespuestaDto<InvitacionDto>()
					{
						Data = _mapper.Map<Invitacion, InvitacionDto>(invitacionDeDb)
					};
				}
			}

			return new RespuestaDto<InvitacionDto>()
			{
				Error = "Id de invitacion no existe",
				Exito = false
			};
		}

		public async Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitaciones()
		{
			var respuesta = new RespuestaDto<List<InvitacionDto>>();
			try
			{
				respuesta.Data = _mapper.Map<IEnumerable<Invitacion>, IEnumerable<InvitacionDto>>(_db.Invitaciones).ToList();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return respuesta;
		}

		public async Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitacionesActuales(string todayString)
		{
			var respuesta = new RespuestaDto<List<InvitacionDto>>();
			try
			{
				DateTime today = DateTime.ParseExact(todayString, "yyyyMMdd", null);
                today = today.AddHours(-today.Hour).AddMinutes(-today.Minute).AddSeconds(-today.Second - 1).AddMilliseconds(-today.Millisecond);
                respuesta.Data = _mapper.Map<IEnumerable<Invitacion>, IEnumerable<InvitacionDto>>(_db.Invitaciones.Where(r => r.FechaEntera >= today).OrderBy(r => r.FechaEntera)).ToList();
            }
			catch (Exception ex)
			{
				throw ex;
			}
			return respuesta;
		}

		public async Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitacionesPasadas(string todayString)
		{
			var respuesta = new RespuestaDto<List<InvitacionDto>>();
			try
			{
				DateTime today = DateTime.ParseExact(todayString, "yyyyMMdd", null);
                today = today.AddHours(-today.Hour).AddMinutes(-today.Minute).AddSeconds(-today.Second - 1).AddMilliseconds(-today.Millisecond);
                respuesta.Data = _mapper.Map<IEnumerable<Invitacion>, IEnumerable<InvitacionDto>>(_db.Invitaciones.Where(r => r.FechaEntera < today).OrderBy(r => r.FechaEntera)).ToList();
            }
			catch (Exception ex)
			{
				throw ex;
			}
			return respuesta;
		}

		public async Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitacionesDelMes(string firstDayOfMonthString)
		{
			var respuesta = new RespuestaDto<List<InvitacionDto>>();
            try
            {
				DateTime firstDayOfMonth = DateTime.ParseExact(firstDayOfMonthString, "yyyyMMdd", null);
                int daysInMonth = DateTime.DaysInMonth(firstDayOfMonth.Year, firstDayOfMonth.Month);
                DateTime lastDayOfMonth = new DateTime(firstDayOfMonth.Year, firstDayOfMonth.Month, daysInMonth);
                respuesta.Data = _mapper.Map<IEnumerable<Invitacion>, IEnumerable<InvitacionDto>>(_db.Invitaciones
					.Where(r => r.FechaEntera >= firstDayOfMonth && r.FechaEntera <= lastDayOfMonth)
					.OrderBy(r => r.FechaEntera)).ToList();
            }
			catch (Exception ex)
			{
				throw ex;
			}
			return respuesta;
		}

		public async Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitacionesDelaSemana(string todayString)
		{
			var respuesta = new RespuestaDto<List<InvitacionDto>>();
			try
			{
				DateTime today= DateTime.ParseExact(todayString, "yyyyMMdd", null);
				// Determine the day of the week for the given date.
				DayOfWeek dayOfWeek = today.DayOfWeek;

				// Calculate the date of the first day of the week by subtracting the day of the week from the given date.
				int daysSinceMonday = ((int)dayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
				DateTime firstDayOfWeek = today.AddDays(-daysSinceMonday);

				// Calculate the date of the last day of the week by adding the number of days until Sunday to the given date.
				int daysUntilSunday = 7 - daysSinceMonday - 1;
				DateTime lastDayOfWeek = today.AddDays(daysUntilSunday);

				respuesta.Data = _mapper.Map<IEnumerable<Invitacion>, IEnumerable<InvitacionDto>>(_db.Invitaciones.Where(r => r.FechaEntera >= firstDayOfWeek && r.FechaEntera <= lastDayOfWeek).OrderBy(r => r.FechaEntera)).ToList();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return respuesta;
		}
	}
}
