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
    @Input() exerciseToUpdate: ExerciseUpdate;
    exerciseForm = new FormGroup({
        id: new FormControl(0, [Validators.required]),
        name: new FormControl('', [Validators.required]),
        description: new FormControl(''),
    });
    loading = false;

    get id() {
        return this.exerciseForm.get('id');
    }

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
                id: this.exerciseToUpdate.id,
                name: this.exerciseToUpdate.name,
                description: this.exerciseToUpdate.description,
            });
        }
    }

    onExerciseFormSubmit() {
        this.loading = true;
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

    updateExercise() {
        const exercise: ExerciseUpdate = {
            id: this.id.value,
            name: this.name.value,
            description: this.description.value,
        };

        this.exercisesService.updateExercise(exercise).subscribe({
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
