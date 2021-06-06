export interface Blog {
    id: number;
    title: string;
    photoUrl: string;
    description: string;
    shortDescription: string;
    isLike: boolean;
    countLikes: number;
    username?: string;
}
