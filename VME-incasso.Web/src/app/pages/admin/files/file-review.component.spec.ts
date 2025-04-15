import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FileReviewComponent } from './file-review.component';

describe('FileReviewComponent', () => {
  let component: FileReviewComponent;
  let fixture: ComponentFixture<FileReviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FileReviewComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FileReviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
