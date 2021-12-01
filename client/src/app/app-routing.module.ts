import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestErrorComponent } from './core/test-error/test-error.component';

const routes: Routes = [
    { path: 'test-error', component: TestErrorComponent },
    {
        path: 'exercises',
        loadChildren: () =>
            import('./exercises/exercises.module').then((mod) => mod.ExercisesModule),
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
