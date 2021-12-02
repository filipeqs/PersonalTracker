import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ExerciseDetails } from 'src/app/shared/models/exercises';
import { ExercisesService } from '../exercises.service';

@Component({
    selector: 'app-exercise-details',
    templateUrl: './exercise-details.component.html',
    styleUrls: ['./exercise-details.component.scss'],
})
export class ExerciseDetailsComponent implements OnInit {
    exercise: ExerciseDetails;
    loading = false;

    constructor(private route: ActivatedRoute, private exerciseService: ExercisesService) {}

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
