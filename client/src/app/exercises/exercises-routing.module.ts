import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExerciseAddComponent } from './exercise-add/exercise-add.component';
import { ExerciseDetailsComponent } from './exercise-details/exercise-details.component';
import { ExerciseUpdateComponent } from './exercise-update/exercise-update.component';
import { ExercisesComponent } from './exercises.component';

const routes: Routes = [
    { path: '', component: ExercisesComponent },
    { path: 'create', component: ExerciseAddComponent },
    { path: 'edit/:id', component: ExerciseUpdateComponent },
    { path: ':id', component: ExerciseDetailsComponent },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ExercisesRoutingModule {}
