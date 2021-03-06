﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaOtacaAglr.Data.DataBaseContext;
using BibliotecaOtacaAglr.Models.Manga_Capitulo_Paginas.Entity;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using BibliotecaOtacaAglr.Models.Others.Entity.ApiResponse;

namespace BibliotecaOtacaAglr.Controllers.Mangas
{
    [Route("api/Manga/{mangaid}/Capitulo/{capituloid}/Pagina")]
    [ApiController]
    [Authorize]
    public class Manga_Capitulo_PaginaController : ControllerBase
    {
        private readonly BibliotecaOtakaBDContext _context;

        public Manga_Capitulo_PaginaController(BibliotecaOtakaBDContext context)
        {
            _context = context;
        }

        // GET: api/Manga/5/Capitulo/5/Paginas/Lista
        [HttpGet("Lista")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Manga_Capitulo_Pagina>>> ObtenerCapituloPaginas(int capituloid)
        {
            List<Manga_Capitulo_Pagina> paginas = await _context.Manga_Capitulo_Paginas.Where(p => p.Manga_CapituloId == capituloid).OrderBy(p => p.Numero_pagina).ToListAsync();
            return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Dato = paginas });
        }

        // GET: api/Manga/5/Capitulo/5/Paginas/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Manga_Capitulo_Pagina>> ObtenerPaginas(int id)
        {
            Manga_Capitulo_Pagina paginas = await _context.Manga_Capitulo_Paginas.FindAsync(id);

            if (paginas == null)
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "Pagina inexistente" });
            }

            return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Dato = paginas });
        }

        // POST: api/Manga/5/Capitulo/5/Paginas/Agregar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("Agregar")]
        public async Task<ActionResult<Manga_Capitulo_Pagina>> AgregarPaginas([FromBody] Manga_Capitulo_Pagina paginas, [FromForm] IFormFile pagina)
        {
            try
            {
                if (pagina == null)
                {
                    return BadRequest(new ApiResponseFormat() { Estado = StatusCodes.Status400BadRequest, Mensaje = "Pagina invalida" });
                }

                MemoryStream ms = new MemoryStream();
                pagina.CopyTo(ms);
                paginas.Pagina = ms.ToArray();

                _context.Manga_Capitulo_Paginas.Add(paginas);
                await _context.SaveChangesAsync();

                return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status201Created, Mensaje = "Pagina subida exitosamente", Dato = paginas });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseFormat() { Estado = ex.HResult, Mensaje = ex.Message });
            }
        }

        // DELETE: api/Manga/5/Capitulo/5/Paginas/Eliminar/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<ActionResult<Manga_Capitulo_Pagina>> DeletePaginas(int id)
        {
            Manga_Capitulo_Pagina paginas = await _context.Manga_Capitulo_Paginas.Where(p => p.PaginaId == id).FirstOrDefaultAsync();

            if (paginas == null)
            {
                return NotFound(new ApiResponseFormat() { Estado = StatusCodes.Status404NotFound, Mensaje = "pagina invalida" });
            }

            try
            {
                _context.Manga_Capitulo_Paginas.Remove(paginas);
                await _context.SaveChangesAsync();

                return Ok(new ApiResponseFormat() { Estado = StatusCodes.Status200OK, Dato = paginas });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseFormat() { Estado = ex.HResult, Mensaje = ex.Message });
            }
        }
    }
}
