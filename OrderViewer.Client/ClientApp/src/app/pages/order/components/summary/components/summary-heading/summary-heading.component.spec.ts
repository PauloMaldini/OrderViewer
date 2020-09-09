import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SummaryHeadingComponent } from './summary-heading.component';

describe('SummaryHeadingComponent', () => {
  let component: SummaryHeadingComponent;
  let fixture: ComponentFixture<SummaryHeadingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SummaryHeadingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SummaryHeadingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
