interface BookData {
  id: number;
  title: string;
  description: string;
  prize: number;
  isActive: boolean;
  userId: number;
  user: AuthorData;
}
