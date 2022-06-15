using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_JuegoWiki
{
    public static class RolesAutomaticos
    {
        public static void EjecutarRoles(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            InicializarRoles(roleManager);
            InicializarUsuarios(userManager);
        }

        private static void InicializarRoles(RoleManager<IdentityRole> roleManager)
        {
            //Si no existe aún el rol de Administrador
            if (!roleManager.RoleExistsAsync("Administrador").Result)
            {
                //Creamos el objeto rol y lo añadimos a la listas de roles
                var rol = new IdentityRole
                {
                    Name = "Administrador"
                };
                //Es necesario almacenar el rol en una variable .Result
                var result = roleManager.CreateAsync(rol).Result;
            }
            //Hacemos lo mismo con el rol Usuario
            if (!roleManager.RoleExistsAsync("Usuario").Result)
            {
                var rol = new IdentityRole
                {
                    Name = "Usuario"
                };
                var result = roleManager.CreateAsync(rol).Result;
            }
        }

        private static void InicializarUsuarios(UserManager<IdentityUser> userManager)
        {
            //Si aún no existe la cuenta administrador
            if(userManager.FindByNameAsync("admin1@administrador.admn").Result == null)
            {
                //Creamos el objeto cuenta
                var admin = new IdentityUser
                {
                    UserName = "admin1@administrador.admn",
                    Email = "admin1@administrador.admn",
                    EmailConfirmed = true
                };
                //Lo añadimos a la lista de usuarios junto a una contraseña
                var result = userManager.CreateAsync(admin, "C@ntrasenia_1").Result;
                //Si se crea correctamente, asignamos a la cuenta nueva el rol de administrador
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, "Administrador").Wait();
                }
            }
        }
    }
}
