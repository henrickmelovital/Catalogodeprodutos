import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CategoriasComponent } from './components/categorias/categorias.component';
import { ProdutoDetalheComponent } from './components/produtos/produto-detalhe/produto-detalhe.component';

import { ProdutoListaComponent } from './components/produtos/produto-lista/produto-lista.component';
import { ProdutoService } from './services/produto.service';
import { ProdutosComponent } from './components/produtos/produtos.component';

import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';

import { ContatosComponent } from './components/contatos/contatos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';


const routes: Routes = [
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'registration', component: RegistrationComponent },
    ]
  },
  {
    path: 'user/perfil', component: UserComponent
  },
  { path: 'produtos', redirectTo: 'produtos/lista' },
  {
    path: 'produtos', component: ProdutosComponent,
    children: [
      { path: 'detalhe/:id', component: ProdutoDetalheComponent },
      { path: 'detalhe', component: ProdutoDetalheComponent },
      { path: 'lista', component: ProdutoListaComponent },
    ],
  },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'palestrantes', component: CategoriasComponent },
  { path: 'contatos', component: ContatosComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
