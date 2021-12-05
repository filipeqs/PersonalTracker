import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ExerciseDetails } from 'src/app/shared/models/exercises';
import { ExercisesService } from '../exercises.service';

@Component({
    selector: 'app-exercise-update',
    templateUrl: './exercise-update.component.html',
    styleUrls: ['./exercise-update.component.scss'],
})
export class ExerciseUpdateComponent implements OnInit {
    loading = false;
    exercise: ExerciseDetails;

    constructor(private exerciseService: ExercisesService, private route: ActivatedRoute) {}

    ngOnInit(): void {
        this.loading = true;
        this.route.paramMap.subscribe((params) => {
            const id = +params.get('id');
            this.exerciseService.getExerciseDetails(id).subscribe({
                next: (exercise) => {
                    this.loading = false;
                    this.exercise = exercise;
                },
                error: (error) => {
                    this.loading = false;
                    console.log(error);
                },
            });
        });
    }
}
