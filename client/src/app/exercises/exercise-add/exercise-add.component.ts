import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ExerciseCreate } from 'src/app/shared/models/exercises';

@Component({
    selector: 'app-exercise-add',
    templateUrl: './exercise-add.component.html',
    styleUrls: ['./exercise-add.component.scss'],
})
export class ExerciseAddComponent implements OnInit {
    exerciseForm = new FormGroup({
        name: new FormControl('', [Validators.required]),
        description: new FormControl(''),
    });

    get name() {
        return this.exerciseForm.get('name');
    }

    constructor() {}

    ngOnInit(): void {}

    onCreateExercise() {
        console.log(this.exerciseForm.value);
    }
}
