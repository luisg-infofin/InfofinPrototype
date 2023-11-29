import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';


@Component({
  selector: 'app-add-person',
  templateUrl: './add-person.component.html',
  styleUrl: './add-person.component.css'
})
export class AddPersonComponent {

  email: FormControl;
  name: FormControl;
  address: FormControl;

  constructor(public dialogRef: MatDialogRef<AddPersonComponent>,) {
    this.email = new FormControl('', [Validators.required, Validators.email]);
    this.name = new FormControl('', [Validators.required]);
    this.address = new FormControl('');
  }

  ngOnInit() {
    this.dialogRef.updateSize('80%', '40%');
  }

  onCancel(): void {
    this.dialogRef.close();
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

    if (this.email.valid && this.name.valid) {
      this.dialogRef.close({ name: this.name.value, email: this.email.value, address: this.address.value });
    }
  }

}
