using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WizardVS.Models;

namespace WizardVS.Controllers
{
    public class EmpleadosController : Controller
{
    private readonly AppDbContext context;
 
    public EmpleadosController(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<IActionResult> Index()
        {
            return View(await context.Empleados.ToListAsync());
        }
    public ActionResult Create()
    {
        return View("PersonalInfo");
    }
    private Empleado GetEmpleado()
    {
        if (HttpContext.Session.GetObject<Empleado>("DataObject") == null)
        {
            HttpContext.Session.SetObject("DataObject", new Empleado());
        }
        return (Empleado)HttpContext.Session.GetObject<Empleado>("DataObject");
    }
    private void RemoveEmpleado()
    {
        HttpContext.Session.SetObject("DataObject", null);
    }
    [HttpPost]
    public ActionResult PersonalInfo(EmpleadoPersonalViewModel personal, string BtnPrevious, string BtnNext)
    {
        if (BtnNext != null)
        {
            
                Empleado empleado = GetEmpleado();
                empleado.Nombres = personal.Nombres;
                empleado.Apellidos = personal.Apellidos;
                empleado.Domicilio = personal.Domicilio;
 
                HttpContext.Session.SetObject("DataObject", empleado);
 
                return View("LaboralInfo");
        }
        
        return View();
    }
 
    [HttpPost]
    public ActionResult LaboralInfo(EmpleadoLaboralViewModel laboral, string BtnPrevious, string BtnNext, string BtnCancel)
    {
        Empleado empleado = GetEmpleado();
 
        if (BtnPrevious != null)
        {
            EmpleadoPersonalViewModel info = new EmpleadoPersonalViewModel();
            info.Nombres = empleado.Nombres;
            info.Apellidos = empleado.Apellidos;
            info.Domicilio = empleado.Domicilio;
 
            return View("PersonalInfo", info);
        }
        if (BtnNext != null)
        {
            
                empleado.Departamento = laboral.Departamento;
                empleado.FechaIngreso = laboral.FechaIngreso.ToUniversalTime();
                empleado.Salario = laboral.Salario;
                 
                context.Empleados.Add(empleado);
                context.SaveChanges();
                RemoveEmpleado();
 
                return View("Index");
        }
        if (BtnCancel != null)
            RemoveEmpleado();
        return View();
    }
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await context.Empleados
                .FirstOrDefaultAsync(m => m.id_empleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                context.Empleados.Remove(empleado);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("id_empleado,Nombres,Apellidos,Domicilio,Departamento,FechaIngreso,Salario")] Empleado empleado)
        {
            if (id != empleado.id_empleado)
            {
                return View("Index");
            }

            if (ModelState.IsValid)
            {
                try
                {
                var data = await context.Empleados.FindAsync(id);
         
            data.Nombres = empleado.Nombres;
            data.Apellidos = empleado.Apellidos;
            data.Domicilio = empleado.Domicilio;
                data.Departamento = empleado.Departamento;
                data.FechaIngreso = empleado.FechaIngreso.ToUniversalTime();
                data.Salario = empleado.Salario;
                 
        
                    context.Empleados.Update(data);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.id_empleado))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }
        private bool EmpleadoExists(int id)
        {
            return context.Empleados.Any(e => e.id_empleado == id);
        }
}
}