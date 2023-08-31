import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { ProdutoService } from 'src/app/services/produto.service';
import { Produto } from 'src/app/models/Produto';
import { ProdutosComponent } from '../produtos.component';


@Component({
  selector: 'app-produto-lista',
  templateUrl: './produto-lista.component.html',
  styleUrls: ['./produto-lista.component.scss']
})
export class ProdutoListaComponent implements OnInit {

  modalRef: BsModalRef | undefined;
  public produtos: Produto[] = [];
  public produtosFiltrados: Produto[] = [];

  public larguraImagem = 150;
  public margemImagem = 2;
  public exibirImagem = true;
  private filtroListado = '';

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    // this.produtosFiltrados = this.filtroLista ? this.produtosFiltrados(this.filtroLista) : this.produtos;
  }

  public filtrarEventos(filtrarPor: string): Produto[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.produtos.filter(
      evento => evento.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.descricao.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(
    private eventoService: ProdutoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    // private spinner: NgxSpinnerService,
    private router: Router
  ) { }

  public ngOnInit(): void {
    // this.spinner.show();
    this.getProdutos();
  }

  public getProdutos(): void {
    this.eventoService.getEventos().subscribe({
      next: (eventos: Produto[]) => {
        this.produtos = eventos;
        this.produtosFiltrados = this.produtos;
      },
      error: (error: any) => {
        // this.spinner.hide();
        this.toastr.error('Erro ao Carregar os Produtos', 'Erro!');
      },
      // complete: () => this.spinner.hide()
    });
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  // confirm(): void {
  //   this.modalRef.hide();
  //   this.toastr.success('O Produto foi deletado com Sucesso.', 'Deletado!');
  // }

  // decline(): void {
  //   this.modalRef.hide();
  // }

  detalheProduto(id: number): void{
    this.router.navigate([`produtos/detalhe/${id}`]);
  }

}
