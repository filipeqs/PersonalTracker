import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExerciseAddComponent } from './exercise-add/exercise-add.component';
import { ExerciseDetailsComponent } from './exercise-details/exercise-details.component';
import { ExercisesComponent } from './exercises.component';

const routes: Routes = [
    { path: '', component: ExercisesComponent },
    { path: 'create', component: ExerciseAddComponent },
    { path: ':id', component: ExerciseDetailsComponent },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ExercisesRoutingModule {}
