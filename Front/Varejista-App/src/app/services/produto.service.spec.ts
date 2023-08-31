import { TestBed, inject, waitForAsync } from '@angular/core/testing';
import { ProdutoService } from './produto.service';

describe('Service: Evento', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProdutoService]
    });
  });

  it('should ...', inject([ProdutoService], (service: ProdutoService) => {
    expect(service).toBeTruthy();
  }));
});
