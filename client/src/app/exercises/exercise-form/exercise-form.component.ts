import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ExerciseCreate, ExerciseUpdate } from 'src/app/shared/models/exercises';
import { ExercisesService } from '../exercises.service';

@Component({
    selector: 'app-exercise-form',
    templateUrl: './exercise-form.component.html',
    styleUrls: ['./exercise-form.component.scss'],
})
export class ExerciseFormComponent implements OnInit {
    @Input() isEdit = false;
    @Input() exercise: ExerciseUpdate;
    exerciseForm = new FormGroup({
        id: new FormControl(0, [Validators.required]),
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

    ngOnInit(): void {
        if (this.isEdit) {
            this.exerciseForm.patchValue({
                id: this.exercise.id,
                name: this.exercise.name,
                description: this.exercise.description,
            });
        }
    }

    onCreateExercise() {
        if (this.isEdit) {
            this.updateExercise();
        } else {
            this.createExercise();
        }
    }

    createExercise() {
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

    updateExercise() {}
}
