import { StudentDetailService } from './../services/student-detail.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormArray, FormGroup  } from '@angular/forms';

@Component({
  selector: 'app-student-detail',
  templateUrl: './student-detail.component.html',
  styles: []
})

export class StudentDetailComponent implements OnInit {

  studentForms: FormArray = this.fb.array([]);
  notification = null;

  constructor(private fb: FormBuilder, private studentService: StudentDetailService) { }

  ngOnInit(): void {
    this.studentForms.clear();
    this.studentService.getStudents().subscribe(
      res => {
        if (res === []) {
          this.addStudentForm();
        } else {
          (res as []).forEach((student: any) => {
            this.studentForms.push(this.fb.group({
              id: [student.id],
              name: [student.name],
              email: [student.email],
              dni: [student.dni],
              chairNumber: [student.chairNumber]
            }));
          });
        }
      }
    );
  }

  addStudentForm() {
    this.studentForms.push(this.fb.group({
      id: [this.returnGuidEmpty()],
      name: [''],
      email: [''],
      dni: [''],
      chairNumber: [0],
    }));
  }

  recordSubmit(fg: FormGroup) {
    let message = 'update';
    if (fg.value.id === this.returnGuidEmpty()) {
      message = 'insert';
    }
    this.studentService.postStudent(fg.value).subscribe(
        (res: any) => {
           // fg.patchValue({ id: res.id });
           this.showNotification(message);
           this.ngOnInit();
         });
   // } //else {
      // this.studentService.putStudent(fg.value).subscribe(
         // (res: any) => {
         // this.showNotification('update');
         // });
   // }
  }

  returnGuidEmpty() {
    return '00000000-0000-0000-0000-000000000000';
  }

  onDelete(id, i) {
    if (id === this.returnGuidEmpty()) {
      this.studentForms.removeAt(i);
    } else if (confirm('Are you sure to delete this record ?')) {
      this.studentService.deleteStudent(id).subscribe(
        (res) => {
          this.studentForms.removeAt(i);
          this.showNotification('delete');
        });
     }
  }

  showNotification(category) {
    switch (category) {
      case 'insert':
        this.notification = { class: 'text-success', message: 'saved!' };
        break;
      case 'update':
        this.notification = { class: 'text-primary', message: 'updated!' };
        break;
      case 'delete':
        this.notification = { class: 'text-danger', message: 'deleted!' };
        break;

      default:
        break;
    }
    setTimeout(() => {
      this.notification = null;
    }, 3000);
  }

}
