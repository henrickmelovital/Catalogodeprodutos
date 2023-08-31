import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-produto-detalhe',
  templateUrl: './produto-detalhe.component.html',
  styleUrls: ['./produto-detalhe.component.scss']
})
export class ProdutoDetalheComponent implements OnInit {

  form!: FormGroup;

  get f(): any{
    return this.form.controls;
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }

  public validation(): void {
    this.form = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      preco: ['', [Validators.required]],
      descricao: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(200)]],
      quantidade: ['', [Validators.required]],
      dataCadastro: ['', [Validators.required]],
      categoria: ['', [Validators.required]],

    })
  }

  public resetForm(): void {
    this.form.reset();
  }
}
