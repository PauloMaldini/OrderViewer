import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SummaryItemsComponent } from './summary-items.component';

describe('SummaryItemsComponent', () => {
  let component: SummaryItemsComponent;
  let fixture: ComponentFixture<SummaryItemsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SummaryItemsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SummaryItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
