using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CQRS_DesignPattern.Models;
using CQRS_DesignPattern.Repositories;
using CQRS_DesignPattern.Repositories.Interfaces;
using CQRS_DesignPattern.Repositories.Implementation;
using CQRS_DesignPattern.CommandsManager.Interfaces;
using CQRS_DesignPattern.CommandsManager.Implementation;
using CQRS_DesignPattern.QueriesManager.Interfaces;
using CQRS_DesignPattern.QueriesManager.Implementation;

namespace CQRS_DesignPattern.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeCommandsManager _employeeCommandsManager;
        private readonly IEmployeeQueriesManager _employeeQueriesManager;

        public EmployeesController(IEmployeeCommandsManager employeeCommandsManager, IEmployeeQueriesManager employeeQueriesManager)
        {
            _employeeCommandsManager = employeeCommandsManager;
            _employeeQueriesManager = employeeQueriesManager;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _employeeQueriesManager.GetAll().ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var employee = await _employeeQueriesManager.FindByIdAsync((int)id);

            if (id == null || employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                int added = await _employeeCommandsManager.AddAsync(employee);
                if (added > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var employee = await _employeeQueriesManager.FindByIdAsync((int)id);

            if (id == null || employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int updated = await _employeeCommandsManager.UpdateAsync(employee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await EmployeeExistsAsync(employee.Id))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var employee = await _employeeQueriesManager.FindByIdAsync((int)id);

            if (id == null || employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _employeeQueriesManager.FindByIdAsync(id);

            if (employee != null)
            {
                var deleted = await _employeeCommandsManager.DeleteAsync(employee);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EmployeeExistsAsync(int id)
        {
            var employee = await _employeeQueriesManager.FindByIdAsync(id);
            if (employee != null)
            {
                return true;
            }
            return false;
        }
    }
}
