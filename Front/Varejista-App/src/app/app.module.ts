import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContatosComponent } from './components/contatos/contatos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ProdutosComponent } from './components/produtos/produtos.component';
import { CategoriasComponent } from './components/categorias/categorias.component';
import { UserComponent } from './components/user/user.component';
import { ProdutoDetalheComponent } from './components/produtos/produto-detalhe/produto-detalhe.component';
import { ProdutoListaComponent } from './components/produtos/produto-lista/produto-lista.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ProdutoService } from './services/produto.service';
import { TituloComponent } from './shared/titulo/titulo.component';

@NgModule({
  declarations: [
    AppComponent,
    ProdutosComponent,
    CategoriasComponent,
    ContatosComponent,
    DashboardComponent,
    TituloComponent,
    CategoriasComponent,
    DateTimeFormatPipe,
    ProdutoDetalheComponent,
    ProdutoListaComponent,
    UserComponent,
    ProdutoDetalheComponent,
    LoginComponent,
    RegistrationComponent,

  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,

  ],
  providers: [

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
