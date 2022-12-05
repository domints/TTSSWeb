import Dexie, { Table } from 'dexie';

export interface StopStat {
  id?: number;
  groupId: number;
  name: string;
  useCount: number;
  lastUse: Date;
}

export class AppDB extends Dexie {
  stopStats!: Table<StopStat, number>;
  constructor() {
    super('TTSSWebClient');
    this.version(3).stores({
      stopStats: '++id,groupId,name,useCount,lastUse'
    });
  }
}

export const db = new AppDB();
