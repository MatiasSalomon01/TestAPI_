﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI_.Entities;

namespace TestAPI_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableUnoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TableUnoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetTablaUno")]
        public IActionResult GetTablaUno()
        {
            var entity = _context.TablaUno.Include(t => t.TablaUnoDos).ToList();
            return Ok(entity);
        }

        [HttpPost("AddTablaUno")]
        public IActionResult AddTablaUno(TableModel2 model)
        {
            var list = new List<TablaUnoDos>();

            foreach (var item in model.TablaMiddle)
            {
                var exists = _context.TablaDos.Any(t => t.Id == item);
                if (exists is false)  return BadRequest(new { Message = $"Id {item} no exite en la tabla TablaDos" });
                list.Add(new TablaUnoDos() { TablaDosId = item });
            }
            
            var entity = new TablaUno() { Descripcion = model.Description, TablaUnoDos = list };
            _context.TablaUno.Add(entity);
            _context.SaveChanges();
            return Created(string.Empty, new { entity.Id });
        }

        [HttpGet("GetTablaDos")]
        public IActionResult GetTablaDos()
        {
            var entity = _context.TablaDos.Include(t => t.TablaUnoDos).ToList();
            return Ok(entity);
        }

        [HttpPost("AddTablaDos")]
        public IActionResult AddTablaDos(TableModel2 model)
        {
            var list = new List<TablaUnoDos>();

            foreach (var item in model.TablaMiddle)
            {
                var exists = _context.TablaUno.Any(t => t.Id == item);
                if (exists is false) return BadRequest(new { Message = $"Id {item} no exite en la tabla TablaUno" });
                list.Add(new TablaUnoDos() { TablaUnoId = item });
            }

            var entity = new TablaDos() { Descripcion = model.Description, TablaUnoDos = list };
            _context.TablaDos.Add(entity);
            _context.SaveChanges();
            return Created(string.Empty, new { entity.Id });
        }
    }
    public class TableModel2
    {
        public string Description { get; set; }
        public List<int> TablaMiddle { get; set; }
    }
}
