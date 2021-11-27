import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { ExerciseList } from '../shared/models/exercises';

@Injectable({
    providedIn: 'root',
})
export class ExercisesService {
    baseApiUrl = environment.apiUrl;
    private exercisesSource = new BehaviorSubject<ExerciseList[]>([]);
    exercises$ = this.exercisesSource.asObservable();

    constructor(private http: HttpClient) {}

    getCurrentExercises() {
        return this.exercisesSource.value;
    }

    getExercises() {
        return this.http.get<ExerciseList[]>(this.baseApiUrl + '/exercises').pipe(
            map((exercises) => {
                this.exercisesSource.next(exercises);
            }),
        );
    }
}
