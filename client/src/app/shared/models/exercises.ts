export interface ExerciseList {
    id: number;
    name: string;
}

export interface ExerciseDetails {
    id: number;
    name: string;
    description: string;
}

export interface ExerciseCreate {
    name: string;
    description: string;
}
