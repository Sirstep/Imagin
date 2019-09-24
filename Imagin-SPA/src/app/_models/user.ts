import { Photo } from './photo';

export interface User {
    id: number;
    username: string;
    created: Date;
    lastActive: Date;
    photoUrl: string;
    description: string;
    photos?: Photo[];
}
