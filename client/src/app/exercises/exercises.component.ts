import { Component, OnInit } from '@angular/core';
import { ExerciseList } from '../shared/models/exercises';
import { ExercisesService } from './exercises.service';

@Component({
    selector: 'app-exercises',
    templateUrl: './exercises.component.html',
    styleUrls: ['./exercises.component.scss'],
})
export class ExercisesComponent implements OnInit {
    exercises: ExerciseList[];

    constructor(private exerciseService: ExercisesService) {}

    ngOnInit(): void {
        this.exerciseService.getExercises().subscribe((exercises) => {
            this.exercises = exercises;
        });
    }
}
