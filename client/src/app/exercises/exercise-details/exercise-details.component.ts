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

    constructor(private route: ActivatedRoute, private exerciseService: ExercisesService) {}

    ngOnInit(): void {
        this.route.paramMap.subscribe((params) => {
            const id = +params.get('id');
            this.exerciseService.getExerciseDetails(id).subscribe((exercise) => {
                this.exercise = exercise;
            });
        });
    }
}
