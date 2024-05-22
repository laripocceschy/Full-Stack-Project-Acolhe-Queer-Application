using Microsoft.CodeAnalysis.Options;
using System;

namespace acolhequeer_app.Views.Account
@model acolhequeer_app.ViewModels.LoginViewModel

<form asp-action="Login" method="post">
    <div class="form-group">
        <label asp-for="Email"></label>
        <input asp-for="Email" class="form-control" />
        <span asp-validation-for="Email" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="Senha"></label>
        <input asp-for="Senha" type="password" class="form-control" />
        <span asp-validation-for="Senha" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="TipoUsuario"></label>
        <select asp-for="TipoUsuario" class="form-control">
            <option value = "Usuario" > Usuário </ option >
            < option value="Admin">Administrador</option>
            <option value = "Instituicao" > Instituição </ option >
        </ select >
        < span asp-validation-for="TipoUsuario" class="text-danger"></span>
    </div>
    <button type = "submit" class="btn btn-primary">Login</button>
</form>

