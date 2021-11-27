import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.prod';
import { ExerciseList } from '../shared/models/exercises';

@Injectable({
    providedIn: 'root',
})
export class ExercisesService {
    baseApiUrl = environment.apiUrl;

    constructor(private http: HttpClient) {}

    getExercises() {
        return this.http.get<ExerciseList[]>(this.baseApiUrl + '/exercises');
    }
}
