import { Component, Inject } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Person } from '../../../../../shared/models/person.model';


@Component({
  selector: 'app-add-person',
  templateUrl: './add-person.component.html',
  styleUrl: './add-person.component.css'
})
export class AddPersonComponent {

  id: FormControl;
  email: FormControl;
  name: FormControl;
  address: FormControl;

  constructor(public dialogRef: MatDialogRef<AddPersonComponent>, @Inject(MAT_DIALOG_DATA) public data: Person) {
    this.email = new FormControl(this.data.email ? this.data.email : '', [Validators.required, Validators.email]);
    this.name = new FormControl(this.data.name ? this.data.name : '', [Validators.required]);
    this.address = new FormControl(this.data.address ? this.data.address : '');
    this.id = new FormControl(this.data.id ? this.data.id : '');
  }

  ngOnInit() {
    this.dialogRef.updateSize('80%', '40%');
  }

  onCancel(): void {
    this.dialogRef.close({
      isCancel: true
    });
  }

  getErrorMessage() {
    if (this.email.hasError('required')) {
      this.email.markAsTouched();
      return 'You must enter a value';
    }

    if (this.name.hasError('required')) {
      this.name.markAsTouched();
      return 'You must enter a value';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

  onOk() {
    if (this.getErrorMessage() !== '') return;

    const isEdit = this.id.value !== '';
    if (this.email.valid && this.name.valid) {
      this.dialogRef.close({
        person: {
          name: this.name.value, email: this.email.value, address: this.address.value, id: this.id.value
        },
        isEdit: isEdit,        
      });
    }
  }

}
