import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ExercisesRoutingModule } from './exercises-routing.module';
import { ExercisesComponent } from './exercises.component';
import { ExerciseDetailsComponent } from './exercise-details/exercise-details.component';
import { ExerciseAddComponent } from './exercise-add/exercise-add.component';

@NgModule({
    declarations: [ExercisesComponent, ExerciseDetailsComponent, ExerciseAddComponent],
    imports: [CommonModule, ExercisesRoutingModule],
})
export class ExercisesModule {}
