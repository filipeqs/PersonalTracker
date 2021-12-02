import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ExerciseCreate } from 'src/app/shared/models/exercises';
import { ExercisesService } from '../exercises.service';

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
    loading = false;

    get name() {
        return this.exerciseForm.get('name');
    }

    get description() {
        return this.exerciseForm.get('description');
    }

    constructor(private exercisesService: ExercisesService, private router: Router) {}

    ngOnInit(): void {}

    onCreateExercise() {
        const exercise: ExerciseCreate = {
            name: this.name.value,
            description: this.description.value,
        };

        this.exercisesService.createExercise(exercise).subscribe({
            next: () => {
                this.loading = false;
                this.router.navigateByUrl('/exercises');
            },
            error: (errors) => {
                console.log(errors);
            },
        });
    }
}
