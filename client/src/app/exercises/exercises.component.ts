import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ExerciseList } from '../shared/models/exercises';
import { ExercisesService } from './exercises.service';

@Component({
    selector: 'app-exercises',
    templateUrl: './exercises.component.html',
    styleUrls: ['./exercises.component.scss'],
})
export class ExercisesComponent implements OnInit {
    exercises$: Observable<ExerciseList[]>;

    constructor(private exerciseService: ExercisesService) {}

    ngOnInit(): void {
        this.exercises$ = this.exerciseService.exercises$;

        this.exerciseService.getExercises().subscribe();
    }
}
